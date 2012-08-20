/*
 * Copyright 2010-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

using Amazon.IdentityManagement.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.IdentityManagement.Model.Internal.MarshallTransformations
{
    /// <summary>
    ///    Response Unmarshaller for GetAccountPasswordPolicy operation
    /// </summary>
    internal class GetAccountPasswordPolicyResponseUnmarshaller : XmlResponseUnmarshaller
    {

        public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context) 
        {
            GetAccountPasswordPolicyResponse response = new GetAccountPasswordPolicyResponse();
            
            while (context.Read())
            {
                if (context.IsStartElement)                
                {
                    if(context.TestExpression("GetAccountPasswordPolicyResult", 2))
                    {
                        response.GetAccountPasswordPolicyResult = GetAccountPasswordPolicyResultUnmarshaller.GetInstance().Unmarshall(context);
                        continue;
                    }
                    if (context.TestExpression("ResponseMetadata", 2))
                    {
                        response.ResponseMetadata = ResponseMetadataUnmarshaller.GetInstance().Unmarshall(context);
                    }
                }
            }
                 
                        
            return response;
        }

        
        public override AmazonServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
        {
            ErrorResponse errorResponse = ErrorResponseUnmarshaller.GetInstance().Unmarshall(context);
            
            if (errorResponse.Code != null && errorResponse.Code.Equals("NoSuchEntity"))
            {
                return new NoSuchEntityException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
            }
    
            return new AmazonIdentityManagementServiceException(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode);
        }
        
        private static GetAccountPasswordPolicyResponseUnmarshaller instance;

        public static GetAccountPasswordPolicyResponseUnmarshaller GetInstance()
        {
            if (instance == null) 
            {
               instance = new GetAccountPasswordPolicyResponseUnmarshaller();
            }
            return instance;
        }
    
    }
}
    