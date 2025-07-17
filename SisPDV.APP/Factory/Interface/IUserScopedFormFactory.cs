namespace SisPDV.APP.Factory.Interface
{
    public interface IUserScopedFormFactory<TForm> where TForm : Form
    {
        TForm Create(int userId);
    }
}
