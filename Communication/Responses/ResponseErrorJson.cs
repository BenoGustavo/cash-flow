namespace Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public ResponseErrorJson(string errorMessage) {
            this.ErrorMessages.Add(errorMessage);
        }

        public ResponseErrorJson(List<string> errorMessages) {
            this.ErrorMessages = errorMessages;
        }
    }
}
