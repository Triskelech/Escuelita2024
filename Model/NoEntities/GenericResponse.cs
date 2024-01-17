namespace LF2_Prueba.NoModelClasses
{
    public class GenericResponse
    {
        public int Status { get; }
        public string Message { get; }

        public GenericResponse(int status, string message)
        {
            Status = status;
            Message = message;
        }

    }
}
