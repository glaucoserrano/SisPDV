using SisPDV.APP.Stock;

namespace SisPDV.APP.Helpers
{
    public static class ProductAutoCompleteHelper
    {
        public static async Task SetupAsync(
            TextBox txtSearch,
            ListBox lstSuggestions,
            Func<Task<List<ProductAutoCompleteItem>>> loadProductsFunc,
            Action<int> onProductSelected)
        {
            var allProducts = await loadProductsFunc();

            txtSearch.TextChanged += (s, e) =>
            {
                var term = txtSearch.Text.Trim().ToLower();

                var filtered = allProducts
                    .Where(p =>
                        p.Display.ToLower().Contains(term) ||
                        p.Code.Contains(term) ||
                        p.Barcode.Contains(term) ||
                        p.SupplierCode.Contains(term))
                    .ToList();

                lstSuggestions.Items.Clear();
                lstSuggestions.Items.AddRange(filtered.Cast<object>().ToArray());
                lstSuggestions.Location = new Point(txtSearch.Left, txtSearch.Bottom);
                lstSuggestions.Width = txtSearch.Width;
                lstSuggestions.Visible = filtered.Any();
            };

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Down && lstSuggestions.Visible)
                {
                    lstSuggestions.Focus();
                    lstSuggestions.SelectedIndex = 0;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter && lstSuggestions.Items.Count > 0)
                {
                    var item = (ProductAutoCompleteItem)lstSuggestions.Items[0];
                    SelectProduct(item);
                    e.Handled = true;
                    lstSuggestions.Visible = false;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    txtSearch.Clear();
                    lstSuggestions.Visible = false;
                    e.SuppressKeyPress = true;
                }
            };

            lstSuggestions.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && lstSuggestions.SelectedItem is ProductAutoCompleteItem selected)
                {
                    SelectProduct(selected);
                    e.Handled = true;
                }
            };

            lstSuggestions.DoubleClick += (s, e) =>
            {
                if (lstSuggestions.SelectedItem is ProductAutoCompleteItem selected)
                {
                    SelectProduct(selected);
                    lstSuggestions.Visible = false;
                }
            };

            void SelectProduct(ProductAutoCompleteItem selected)
            {
                txtSearch.Text = selected.Display;
                lstSuggestions.Visible = false;
                onProductSelected?.Invoke(selected.Id);
                txtSearch.Focus();
            }
        }
    }

}
