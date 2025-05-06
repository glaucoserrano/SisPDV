using SisPDV.APP.Config;
using SisPDV.APP.User;
using SisPDV.Application.Interfaces;
using System.Reflection;
using System.Text.Json;

namespace SisPDV.APP.Main
{
    public partial class MainForm : Form
    {
        private readonly IUserService _userService;
        private readonly int? _userID;
        private readonly string? _userName;

        public MainForm(int? userId, string? userName, IUserService userService)
        {
            InitializeComponent();
            _userID = userId;
            _userName = userName;
            _userService = userService;
            string? version = Assembly.
                GetExecutingAssembly().
                GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion.Split('+')[0];

            this.Text = $"SisPDV - Sistema de Vendas versão: {version}";
            sslUser.Text = $"Usuário: {_userName} - Caixa {GetPDVNumber()} - Data/Hora {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}";

        }

        private static string GetPDVNumber()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config-caixa.json");
            if (!File.Exists(path))
                return "Não configurado";

            var json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<PDVConfig>(json);
            return config?.numberPDV.ToString() ?? "Não configurado";
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var registerUser = new UserAddForm(_userService);
            registerUser.Show();
        }
    }
}
