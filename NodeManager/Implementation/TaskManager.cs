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

        public async Task<UserTask> ExecutFailedUserTask(UserTask task)
        {
            await Task.Run(async () =>
            {
                Thread.Sleep(task.AssignedNode.ExectionLatancy);
                try
                {
                    task.TaskStates.Add(TaskState.InProgress);
                    var actionModel = task.AssignedNode.ExecutableFunctions.FirstOrDefault(q => q.TaskType == task.TaskType);

                    actionModel.ExecutableFunction.Invoke(UtilitieFunctions.ConvertByteArrayToBitmap(task.Image));
                    task.AssignedNode.StorageCapacity = task.AssignedNode.StorageCapacity + (int)task.TaskType;
                    task.TaskStates.Add(TaskState.Done);
                }
                catch (Exception e)
                {
                    task.State = TaskState.Canceld;
                    task.TaskStates.Add(TaskState.Canceld);
                    task.AssignedNode.RaiseTaskFailureEvent(task.AssignedNode.Id, task.ID, task.AssignedNode.NodeType, task.TaskType, e);
                }
            });

            return task;
        }

        public async Task<(List<BaseNode>, List<UserTask>)> ExecutUserTasks(List<BaseNode> baseNodes, List<UserTask> userTasks)
        {
           
                foreach (var node in baseNodes)
                    if (1==1)
                    {
                        foreach (var task in node.AssignedTasks)
                        {
                            var taskFromUserTasks = userTasks.FirstOrDefault(q => q.ID == task.ID);

                            var actionModel = node.ExecutableFunctions.FirstOrDefault(q => q.TaskType == task.TaskType);

                            taskFromUserTasks.State = TaskState.InProgress;
                            task.TaskStates.Add(TaskState.InProgress);

                            if (actionModel.ExecutableFunction != null)
                            {
                                try
                                {
                                    Thread.Sleep(task.AssignedNode.ExectionLatancy);
                                    var t = actionModel.ExecutableFunction.Invoke(UtilitieFunctions.ConvertByteArrayToBitmap(task.Image));
                                    task.State = TaskState.Done;
                                    task.TaskStates.Add(TaskState.Done);
                                    task.IsTaskDone = true;
                                    taskFromUserTasks.State = TaskState.Done;
                                    node.StorageCapacity = node.StorageCapacity + (int)task.TaskType;
                                }
                                catch (Exception e)
                                {
                                    taskFromUserTasks.State = TaskState.Canceld;
                                    task.TaskStates.Add(TaskState.Canceld);
                                    node.RaiseTaskFailureEvent(node.Id, task.ID, node.NodeType, task.TaskType, e);
                                    task.TaskStates.Add(TaskState.AwaitForFreeNode);
                                }
                            }
                        }
                        node.IsAvaliable = true;
                    }
                    else node.RasieNodeFailureEvent(node.Id, node.NodeType);
          
            
            return (baseNodes, userTasks);
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
