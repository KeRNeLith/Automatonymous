﻿// Copyright 2011-2015 Chris Patterson, Dru Sellers
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
namespace Automatonymous
{
    using System;
    using System.Runtime.Serialization;


    [Serializable]
    public class UnknownStateException :
        AutomatonymousException
    {
        public UnknownStateException()
        {
        }

        public UnknownStateException(string machineType, string stateName)
            : base($"The {stateName} state is not defined for the {machineType} state machine")
        {
        }

        protected UnknownStateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
