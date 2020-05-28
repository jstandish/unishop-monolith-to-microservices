using MonoToMicroLambda.Models;

namespace MonoToMicroLambda.Core.Events
{
    public enum State
    {
        NotFound,
        Failed,
        Success,
        Pending,
        InProgress
    }

    public class EventContext
    {
        public State State { get; set; }
        public User RequestingUser { get; set; }

        public bool IsSetRequestingUser
        {
            get { return RequestingUser != null ? true : false; }
        }

        public bool IsStateSuccess
        {
            get { return this.State == State.Success; }
        }


        public bool IsStateNotFound
        {
            get { return this.State == State.NotFound; }
        }


        public bool IsStateFailed
        {
            get { return this.State == State.Failed; }
        }


        public bool IsStatePending
        {
            get { return this.State == State.Pending; }
        }

        public bool IsStateInProgress
        {
            get { return this.State == State.InProgress; }
        }
    }
}