using System;
using System.Collections.Generic;

namespace WorkflowInterfacesExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Workflow workFlow = new Workflow();
            workFlow.Add(new VideoUploader());
            workFlow.Add(new CallWebService());
            workFlow.Add(new SendEmail());
            workFlow.Add(new ChangeStatus());

            WorkFlowEngine workFlowEngine = new WorkFlowEngine();
            workFlowEngine.Run(workFlow);

            Console.ReadLine();
        }
    }

    public interface ITask
    {
        void Execute();
    }

    public interface IWorkFlow
    {
        void Add(ITask task);
        void Remove(ITask task);
        IEnumerable<ITask> GetTasks();
    }

    public class Workflow : IWorkFlow
    {
        private readonly List<ITask> _tasks;

        public Workflow()
        {
            _tasks = new List<ITask>();
        }

        public void Add(ITask task)
        {
            _tasks.Add(task);
        }

        public void Remove(ITask task)
        {
            _tasks.Remove(task);
        }

        public IEnumerable<ITask> GetTasks()
        {
            return _tasks;
        }
    }

    class VideoUploader : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Video uploading");
        }
    }

    class CallWebService : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Calling web service");
        }
    }

    class SendEmail : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Sending an email...");
        }
    }
    class ChangeStatus : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Status changed...");
        }
    }
    public class WorkFlowEngine
    {
        public void Run(IWorkFlow workFlow)
        {
            foreach (ITask I in workFlow.GetTasks())
            {
                I.Execute();
            }
        }
    }
}
