
namespace MessageServer
{
    public interface IMessageServerInterface
   {
      void WriteMessage(string message);

      void InformNavisworksClosed();
   }
}
