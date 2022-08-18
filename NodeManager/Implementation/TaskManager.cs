using FogEnvironment.Domain.Enum;
using FogEnvironment.Domain.Model;
using FogEnvironment.Domain.Model.TaskModels;
using FogEnvironment.ImageProcessService.BLL;
using FogEnvironment.NodeManager.Abstraction;
using System.Drawing;

namespace FogEnvironment.NodeManager.Implementation
{
    public class TaskManager : ITaskManager
    {
        private readonly ImageUtilities imageUtilities;

        public TaskManager()
        {
            imageUtilities = new ImageUtilities();
        }

        public (List<BaseNode>, List<UserTask>) ExecutUserTasks(List<BaseNode> baseNodes, List<UserTask> userTasks)
        {
            foreach (var node in baseNodes)
                foreach (var task in node.AssignedTasks)
                {
                    var actionModel = node.ExecutableFunctions.FirstOrDefault(q => q.TaskType == task.TaskType);
                    
                    if (actionModel.ExecutableFunction != null)
                    {
                        try
                        {
                            actionModel.ExecutableFunction.Invoke(UtilitieFunctions.ConvertByteArrayToBitmap(task.Image));
                        }
                        catch (Exception e )
                        {
                            throw;
                        }
                    }
                }
        }

        public List<BaseNode> OffloadFunctionsToNodes(List<BaseNode> baseNodes)
        {
            foreach (var node in baseNodes)
            {
                node.ExecutableFunctions.Add(new ActionModel { ExecutableFunction = (pic) => imageUtilities.FaceDetection((Bitmap)pic), TaskType = TaskType.FaceDetection });
                node.ExecutableFunctions.Add(new ActionModel { ExecutableFunction = (pic) => imageUtilities.HorizontalFlip((Bitmap)pic), TaskType = TaskType.RotateHorizontaly });
                node.ExecutableFunctions.Add(new ActionModel { ExecutableFunction = (pic) => imageUtilities.ConvertToBlackandWhite((Bitmap)pic), TaskType = TaskType.ConvertToBlackandWhite });
                node.ExecutableFunctions.Add(new ActionModel { ExecutableFunction = (pic) => imageUtilities.CreateThumbnail((Bitmap)pic), TaskType = TaskType.Thumbnail });
                node.ExecutableFunctions.Add(new ActionModel { ExecutableFunction = (pic) => imageUtilities.HorizontalFlip((Bitmap)pic), TaskType = TaskType.RotateHorizontaly });
            }

            return baseNodes;
        }
    }
}
