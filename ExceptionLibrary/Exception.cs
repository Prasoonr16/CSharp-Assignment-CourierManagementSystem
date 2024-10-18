namespace ExceptionLibrary
{
    [Serializable]
    public class TrackingNumberNotFoundException : Exception
    {
        public TrackingNumberNotFoundException() { }
        public TrackingNumberNotFoundException(string message) : base(message) { }
        public TrackingNumberNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected TrackingNumberNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InvalidEmployeeIDException : Exception
    {
        public InvalidEmployeeIDException() { }
        public InvalidEmployeeIDException(string message) : base(message) { }
        public InvalidEmployeeIDException(string message, Exception inner) : base(message, inner) { }
        protected InvalidEmployeeIDException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class CourierNotFoundException : Exception
    {
        public CourierNotFoundException() { }
        public CourierNotFoundException(string message) : base(message) { }
        public CourierNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected CourierNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
