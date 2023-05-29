using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                string message = GetMessageForModel(userId, description);
                if (message != null)
                {
                    model.AddAttribute("action_result", message);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding a task. Please try again later.", ex);
            }
        }

        private string GetMessageForModel(int userId, string description)
        {
            try
            {
                var task = new UserTask(description);
                _taskService.AddTaskForUser(userId, task);
                return null;
            }
            catch (ArgumentException ex) when (ex.Message == "Invalid userId")
            {
                return "Invalid userId";
            }
            catch (ArgumentException ex) when (ex.Message == "User not found")
            {
                return "User not found";
            }
            catch (ArgumentException ex) when (ex.Message == "The task already exists")
            {
                return "The task already exists";
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating a task. Please try again later.", ex);
            }
        }
    }
}