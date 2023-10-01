namespace OrderService.Application.Exceptions;

public class ModelValidationException : Exception
{
    public class ModelAttributesErrors
    {
        public string Field { get; }
        public string Message { get; }

        public ModelAttributesErrors(string message, string field)
        {
            Message = message;
            Field = field;
        }
    }

    public List<ModelAttributesErrors> ModelAttributesErrorsList { get; }

    public ModelValidationException(
        string? message,
        List<ModelAttributesErrors> modelAttributesErrorsList)
        : base(message)
    {
        ModelAttributesErrorsList = modelAttributesErrorsList;
    }

    public ModelValidationException(
        string? message,
        Exception? innerException,
        List<ModelAttributesErrors> modelAttributesErrorsList)
        : base(message, innerException)
    {

        ModelAttributesErrorsList = modelAttributesErrorsList;
    }
}