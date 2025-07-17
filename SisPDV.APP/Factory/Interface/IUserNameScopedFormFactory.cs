namespace SisPDV.APP.Factory.Interface
{
    public interface IUserNameScopedFormFactory<TForm> where TForm : Form
    {
        TForm Create(string userName);
    }
}
