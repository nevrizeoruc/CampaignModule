﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModule.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
    }
}
