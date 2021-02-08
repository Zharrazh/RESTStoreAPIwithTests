﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTStoreAPI.Models.Common
{
    public class BadRequestType : Dictionary<string, string[]>
    {
        public BadRequestType(ActionContext context)
        {
            ConstructErrorMessages(context.ModelState);
        }
        public BadRequestType(ModelStateDictionary modelState)
        {
            ConstructErrorMessages(modelState);
        }

        private void ConstructErrorMessages  (ModelStateDictionary modelState)
        {
            foreach (var keyModelStatePair in modelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    var errorMessages = new string[errors.Count];
                    for (var i = 0; i<errors.Count; i++)
                    {
                        errorMessages[i] = GetErrorMessage(errors[i]);
                    }

                    Add(key, errorMessages);
                }
            }
        }

        static string GetErrorMessage(ModelError error)
        {
            return string.IsNullOrEmpty(error.ErrorMessage) ?
                "The input was not walid" : error.ErrorMessage;
        }
    }

}
