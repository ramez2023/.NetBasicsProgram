/*

Open UserTaskController and UserTaskService classes under Task3 project and change code-based error handling to exception-based one. 

If you notice any violations of open/close principle, fix them. 

No changes in the code under DoNotChange folder are expected. All unit tests should pass successfully. 

*/
using System;
using Task3.DoNotChange;
using Task3.Exceptions;

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
                GetMessageForModel(userId, description);
                return true;
            }
            catch (BaseException e)
            {

                model.AddAttribute("action_result", e.Message.ToString());
                return false;
            }
        }

        private void GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            _taskService.AddTaskForUser(userId, task);
        }
    }
}