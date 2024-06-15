using System;
using UnityEngine;

namespace TTT.Commands
{
    public class CommandExecutor
    {
        public void ExecuteCommand(ICommand commandToExecute, bool isSilent = false)
        {
            if (!commandToExecute.CheckConditions())
            {
                if (isSilent)
                {
                    return;
                }

                Debug.LogError("[CommandExecutor] Execute -> Conditions not satisfied for command: " +
                               commandToExecute.GetType().Name);
                throw new Exception("[CommandExecutor] Execute -> Conditions not satisfied for command: " +
                                    commandToExecute.GetType().Name);
            }

            commandToExecute.Execute();
        }
    }
}