namespace SisPDV.APP.Factory.Interface
{
    public interface IFormFactory<TForm> where TForm : Form
    {
        Form Create();
    }
}
