/*
 * Copyright 2010-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
    using System;
    using System.Net;
    using System.Collections.Generic;
    using ThirdParty.Json.LitJson;
    using Amazon.ElasticMapReduce.Model;
    using Amazon.Runtime;
    using Amazon.Runtime.Internal;
    using Amazon.Runtime.Internal.Transform;

    namespace Amazon.ElasticMapReduce.Model.Internal.MarshallTransformations
    {
      /// <summary>
      /// Response Unmarshaller for AddJobFlowSteps operation
      /// </summary>
      internal class AddJobFlowStepsResponseUnmarshaller : JsonResponseUnmarshaller
      {
        public override AmazonWebServiceResponse Unmarshall(JsonUnmarshallerContext context)
        {
          AddJobFlowStepsResponse response = new AddJobFlowStepsResponse();          
          
          context.Read();
          
          UnmarshallResult(context,response);
          return response;
        }
        
        private static void UnmarshallResult(JsonUnmarshallerContext context,AddJobFlowStepsResponse response)
        {
          
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            while (context.Read())
            {
              
              if (context.TestExpression("StepIds", targetDepth))
              {
                context.Read();
                response.StepIds = new List<String>();
                        StringUnmarshaller unmarshaller = StringUnmarshaller.GetInstance();
                while (context.Read())
                {
                  JsonToken token = context.CurrentTokenType;                
                  if (token == JsonToken.ArrayStart)
                  {
                    continue;
                  }
                  if (token == JsonToken.ArrayEnd)
                  {
                    break;
                  }
                   response.StepIds.Add(unmarshaller.Unmarshall(context));
                }
                continue;
              }
  
                if (context.CurrentDepth <= originalDepth)
                {                   
                    return;
                }
            }
                        
            return;
        }                        
        
        public override AmazonServiceException UnmarshallException(JsonUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
          ErrorResponse errorResponse = JsonErrorResponseUnmarshaller.GetInstance().Unmarshall(context);                    
          
          if (errorResponse.Code != null && errorResponse.Code.Equals("InternalServerErrorException"))
          {
            return new InternalServerErrorException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
          }
  
          return new AmazonElasticMapReduceException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
        }

        private static AddJobFlowStepsResponseUnmarshaller instance;
        public static AddJobFlowStepsResponseUnmarshaller GetInstance()
        {
          if (instance == null)
          {
            instance = new AddJobFlowStepsResponseUnmarshaller();
          }
          return instance;
        }
  
      }
    }
  
