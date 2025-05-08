using SisPDV.Application.DTOs.Menus;
using SisPDV.Application.DTOs.Users;
using SisPDV.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisPDV.APP.PermissionMenu
{
    public partial class PermissionMenuForm : Form
    {
        private readonly IUserService _userService;
        private readonly IMenuService _menuService;
        private readonly IUserMenuService _userMenuService;
        public PermissionMenuForm(
            IUserService userService,
            IMenuService menuService,
            IUserMenuService userMenuService)
        {
            InitializeComponent();
            _userService = userService;
            _menuService = menuService;
            _userMenuService = userMenuService;
        }

        private async void PrmissionMenuForm_Load(object sender, EventArgs e)
        {
            var users = await _userService.GetAllActiveExceptAdminAsync();

            LoadUsersAsync();
            await LoadMenuTree();

        }

        private async Task LoadMenuTree()
        {
            var menus = await _menuService.GetAllMenuAsync();

            var rootMenus = menus.Where(menu => menu.ParentId == null).OrderBy(menu => menu.Order);
            tvMenus.Nodes.Clear();
            tvMenus.CheckBoxes = true;

            foreach (var root in rootMenus)
            {
                var node = CreateTreeNode(root);
                LoadChildMenus(node, menus);
                tvMenus.Nodes.Add(node);
            }
        }

        private void LoadChildMenus(TreeNode node, List<MenuDTO> menus)
        {
            var parentId = (int)node.Tag;
            var children = menus.Where(menu => menu.ParentId == parentId).OrderBy(menu => menu.Order);

            foreach (var child in children)
            {
                var childNode = CreateTreeNode(child);
                LoadChildMenus(childNode, menus);
                node.Nodes.Add(childNode);
            }
        }

        private TreeNode CreateTreeNode(MenuDTO root)
        {
            var node = new TreeNode(root.Title) { Tag = root.Id };

            if(root.FormName== "UserChangePassword")
            {
                node.Checked = true;
                node.ForeColor = Color.Gray;
                node.NodeFont = new Font(tvMenus.Font, FontStyle.Italic);
            }
            return node;
        }

        private async void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedValue is not int userId || userId == 0)
            {
                tvMenus.Nodes.Clear();
                tvMenus.Enabled = true;
                return;
            }
                

            var allowedMenusIds = await _userMenuService.GetUserMenuAsync(userId);

            foreach (TreeNode node in tvMenus.Nodes)
            {
                CheckNodesRecursive(node, allowedMenusIds);
            }
            tvMenus.Enabled = true;
        }

        private void CheckNodesRecursive(TreeNode node, List<int> allowedMenusIds)
        {
            node.Checked = allowedMenusIds.Contains((int)node.Tag);

            foreach (TreeNode child in node.Nodes)
            {
                CheckNodesRecursive(child, allowedMenusIds);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedValue is not int userId)
                return;

            var selectedMenusId = new List<int>();

            foreach (TreeNode node in tvMenus.Nodes)
                GetCheckedNodesRecursive(node, selectedMenusId);

            await _userMenuService.SaveUserPermissionAsync(userId, selectedMenusId);

            MessageBox.Show("Permissões salvas com sucesso!","SisPDV", MessageBoxButtons.OK,MessageBoxIcon.Information);

            cmbUsers.SelectedIndex = 0;
            tvMenus.Nodes.Clear();
            tvMenus.Enabled = false;

            await LoadMenuTree();
        }

        private void GetCheckedNodesRecursive(TreeNode node, List<int> selectedMenusId)
        {
            if (node.Checked)
                selectedMenusId.Add((int)node.Tag);

            foreach(TreeNode child in node.Nodes)
                GetCheckedNodesRecursive(child, selectedMenusId);
        }
        private async void LoadUsersAsync()
        {
            var users = await _userService.GetAllActiveExceptAdminAsync();
            users.Insert(0, new UserSearchResponseDTO { Id = 0, Name = "Selecione Usuário" });

            cmbUsers.DisplayMember = "Name";
            cmbUsers.ValueMember = "Id";
            cmbUsers.DataSource = users;
            cmbUsers.SelectedIndex = 0;

            
        }
    }
}
