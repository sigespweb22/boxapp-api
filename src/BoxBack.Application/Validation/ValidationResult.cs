using System.Collections.Generic;

public class ValidationResult
{
    public static readonly ValidationResult Success;
    
    public ValidationResult()
    {
        errorMessages = new List<string>();
        errorObjects = new List<object>();
        objects = new List<object>();
    }

    public bool IsValid { get; private set; }

    private List<string> errorMessages;
    private List<object> errorObjects;
    private List<object> objects;

    public IEnumerable<string> ErrorMessages
    {
        get { return errorMessages; }
    }

    public IEnumerable<object> ErrorObjects
    {
        get { return errorObjects; }
    }

    public IEnumerable<object> Objects
    {
        get { return objects; }
    }

    public void AddErrorMessage(string errorMessage)
    {
        IsValid = false;
        errorMessages.Add(errorMessage);
    }
    public void AddErrorObject(object errorObject)
    {
        IsValid = false;
        errorObjects.Add(errorObject);
    }

    public void AddObject(object obj)
    {
        IsValid = true;
        objects.Add(obj);
    }
}