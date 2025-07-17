using SisPDV.APP.Main;

namespace SisPDV.APP.Factory.Interface
{
    public interface IMainFormFactory
    {
        MainForm Create(int userId,string userName);
    }
}
