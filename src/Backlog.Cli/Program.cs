﻿using MediatR;
using Microsoft.Practices.Unity;

using static Backlog.UnityConfiguration;

namespace Backlog.Cli
{
    class Program
    {
        public Program(IMediator mediator)
        {
            _mediator = mediator;
        }

        static void Main(string[] args) => GetContainer().Resolve<Program>().ProcessArgs(args);

        public void ProcessArgs(string[] args)
        {

        }

        private readonly IMediator _mediator;
    }
}
