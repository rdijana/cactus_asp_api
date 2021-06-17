﻿using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core.FakeActors
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Fake Api Actor";

        public IEnumerable<int> AllowedUseCases =>Enumerable.Range(1, 40);
    }
}
