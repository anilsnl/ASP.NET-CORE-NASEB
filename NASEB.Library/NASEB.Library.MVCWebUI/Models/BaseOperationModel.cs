namespace NASEB.Library.MVCWebUI.Models
{
    public class BaseOperationModel
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }
    }
}
