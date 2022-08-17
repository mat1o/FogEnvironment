using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;

namespace FogEnvironment.NodeManager.BaseServices
{
    public static class ExtentionMethodUtilities
    {
        public static bool IsAnyTaskAssigned(this List<UserTask> userTasks)
        {
            if (userTasks == null)
                return false;

            if (userTasks.Count == 0 || !userTasks.Any())
                return false;

            return !false;
        }

        public static bool IsNodeAssigend(this UserTask userTask)
        {
            if (userTask.AssignedNode == null)
                return false;

            return !false;
        }
    }
}
