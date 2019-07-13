namespace CmdApi.Models
{

public class Command 
{
    private int _Id = 0;
    private string _HowTo = string.Empty;
    private string _Platform = string.Empty;
    private string _CommandLine = string.Empty;

        public int Id { get => _Id; set => _Id = value; }
        public string HowTo { get => _HowTo; set => _HowTo = value; }
        public string Platform { get => _Platform; set => _Platform = value; }
        public string CommandLine { get => _CommandLine; set => _CommandLine = value; }
    }






}