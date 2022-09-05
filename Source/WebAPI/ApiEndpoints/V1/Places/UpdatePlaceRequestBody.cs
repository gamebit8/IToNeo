﻿using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    public class UpdatePlaceRequestBody : UpdateBaseRequestBody
    {
        public string Address { get; set; }
    }
}
