﻿/*
 * Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Amazon.Util;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Amazon.DynamoDBv2.DocumentModel
{
    public partial class Table
    {
        #region PutItem

        /// <summary>
        /// Puts a document into DynamoDB.
        /// </summary>
        /// <param name="doc">Document to save.</param>
        public void PutItem(Document doc)
        {
            PutItem(doc, null);
        }

        /// <summary>
        /// Puts a document into DynamoDB, using specified configs.
        /// </summary>
        /// <param name="doc">Document to save.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or updated attributes, depending on config.</returns>
        public Document PutItem(Document doc, PutItemOperationConfig config)
        {
            return PutItemHelper(doc, config, false);
        }

        #endregion


        #region GetItem

        /// <summary>
        /// Gets a document from DynamoDB by hash primary key.
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <returns>Document from DynamoDB</returns>
        public Document GetItem(Primitive hashKey)
        {
            return GetItemHelper(MakeKey(hashKey, null), null, false);
        }

        /// <summary>
        /// Gets a document from DynamoDB by hash-and-range primary key.
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <returns>Document from DynamoDB.</returns>
        public Document GetItem(Primitive hashKey, Primitive rangeKey)
        {
            return GetItemHelper(MakeKey(hashKey, rangeKey), null, false);
        }

        /// <summary>
        /// Gets a document from DynamoDB by hash primary key, using specified configs.
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Document from DynamoDB.</returns>
        public Document GetItem(Primitive hashKey, GetItemOperationConfig config)
        {
            return GetItemHelper(MakeKey(hashKey, null), config, false);
        }

        /// <summary>
        /// Gets a document from DynamoDB by hash-and-range primary key,
        /// using specified configs.
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Document from DynamoDB.</returns>
        public Document GetItem(Primitive hashKey, Primitive rangeKey, GetItemOperationConfig config)
        {
            return GetItemHelper(MakeKey(hashKey, rangeKey), config, false);
        }

        /// <summary>
        /// Gets a document from DynamoDB by key.
        /// </summary>
        /// <param name="key">Values that make up the key of the document.</param>
        /// <returns>Document from DynamoDB</returns>
        public Document GetItem(IDictionary<string, DynamoDBEntry> key)
        {
            return GetItemHelper(MakeKey(key), null, false);
        }

        /// <summary>
        /// Gets a document from DynamoDB by key, using specified configs.
        /// </summary>
        /// <param name="key">Key of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Document from DynamoDB.</returns>
        public Document GetItem(IDictionary<string, DynamoDBEntry> key, GetItemOperationConfig config)
        {
            return GetItemHelper(MakeKey(key), config, false);
        }

        #endregion


        #region UpdateItem

        /// <summary>
        /// Update a document in DynamoDB.
        /// </summary>
        /// <param name="doc">Document to update.</param>
        public void UpdateItem(Document doc)
        {
            UpdateHelper(doc, MakeKey(doc), null, false);
        }
        /// <summary>
        /// Update a document in DynamoDB, with key to identify the document.
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="key">Key of the document.</param>
        public void UpdateItem(Document doc, IDictionary<string, DynamoDBEntry> key)
        {
            UpdateHelper(doc, MakeKey(key), null, false);
        }
        /// <summary>
        /// Update a document in DynamoDB, with hash primary key to identify the document.
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="hashKey">Hash key element of the document.</param>
        public void UpdateItem(Document doc, Primitive hashKey)
        {
            UpdateHelper(doc, MakeKey(hashKey, null), null, false);
        }
        /// <summary>
        /// Update a document in DynamoDB, with a hash-and-range primary key
        /// to identify the document.
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        public void UpdateItem(Document doc, Primitive hashKey, Primitive rangeKey)
        {
            UpdateHelper(doc, MakeKey(hashKey, rangeKey), null, false);
        }


        /// <summary>
        /// Update a document in DynamoDB, using specified config.
        /// </summary>
        /// <param name="doc">Document to update.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or updated attributes, depending on config.</returns>
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.UpdateItemOperationConfig"/>
        public Document UpdateItem(Document doc, UpdateItemOperationConfig config)
        {
            return UpdateHelper(doc, MakeKey(doc), config, false);
        }
        /// <summary>
        /// Update a document in DynamoDB, with a key to identify the
        /// document, and using the specified config.
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="key">Key of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or updated attributes, depending on config.</returns>
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.UpdateItemOperationConfig"/>
        public Document UpdateItem(Document doc, IDictionary<string, DynamoDBEntry> key, UpdateItemOperationConfig config)
        {
            return UpdateHelper(doc, MakeKey(key), config, false);
        }
        /// <summary>
        /// Update a document in DynamoDB, with a hash primary key to identify the
        /// document, and using the specified config.
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or updated attributes, depending on config.</returns>
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.UpdateItemOperationConfig"/>
        public Document UpdateItem(Document doc, Primitive hashKey, UpdateItemOperationConfig config)
        {
            return UpdateHelper(doc, MakeKey(hashKey, null), config, false);
        }
        /// <summary>
        /// Update a document in DynamoDB, with a hash-and-range primary key to identify
        /// the document, and using the specified config.
        /// </summary>
        /// <param name="doc">Attributes to update.</param>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or updated attributes, depending on config.</returns>
        /// <seealso cref="Amazon.DynamoDBv2.DocumentModel.UpdateItemOperationConfig"/>
        public Document UpdateItem(Document doc, Primitive hashKey, Primitive rangeKey, UpdateItemOperationConfig config)
        {
            return UpdateHelper(doc, MakeKey(hashKey, rangeKey), config, false);
        }

        #endregion


        #region DeleteItem

        /// <summary>
        /// Delete a document in DynamoDB.
        /// </summary>
        /// <param name="document">Document to delete.</param>
        public void DeleteItem(Document document)
        {
            DeleteHelper(MakeKey(document), null, false);
        }
        /// <summary>
        /// Delete a document in DynamoDB, identified by a hash primary key.
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        public void DeleteItem(Primitive hashKey)
        {
            DeleteHelper(MakeKey(hashKey, null), null, false);
        }
        /// <summary>
        /// Delete a document in DynamoDB, identified by a hash-and-range primary key.
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        public void DeleteItem(Primitive hashKey, Primitive rangeKey)
        {
            DeleteHelper(MakeKey(hashKey, rangeKey), null, false);
        }
        /// <summary>
        /// Delete a document in DynamoDB, identified by a key.
        /// </summary>
        /// <param name="key">Hash key element of the document.</param>
        public void DeleteItem(IDictionary<string, DynamoDBEntry> key)
        {
            DeleteHelper(MakeKey(key), null, false);
        }

        /// <summary>
        /// Delete a document in DynamoDB, using specified configs.
        /// </summary>
        /// <param name="document">Document to delete.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or old attributes, depending on config.</returns>
        public Document DeleteItem(Document document, DeleteItemOperationConfig config)
        {
            return DeleteHelper(MakeKey(document), config, false);
        }
        /// <summary>
        /// Delete a document in DynamoDB, identified by a hash primary key,
        /// using specified configs.
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or old attributes, depending on config.</returns>
        public Document DeleteItem(Primitive hashKey, DeleteItemOperationConfig config)
        {
            return DeleteHelper(MakeKey(hashKey, null), config, false);
        }
        /// <summary>
        /// Delete a document in DynamoDB, identified by hash-and-range primary key,
        /// using the specified configs.
        /// </summary>
        /// <param name="hashKey">Hash key element of the document.</param>
        /// <param name="rangeKey">Range key element of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or old attributes, depending on config.</returns>
        public Document DeleteItem(Primitive hashKey, Primitive rangeKey, DeleteItemOperationConfig config)
        {
            return DeleteHelper(MakeKey(hashKey, rangeKey), config, false);
        }
        /// <summary>
        /// Delete a document in DynamoDB, identified by a key, using specified configs.
        /// </summary>
        /// <param name="key">Key of the document.</param>
        /// <param name="config">Configuration to use.</param>
        /// <returns>Null or old attributes, depending on config.</returns>
        public Document DeleteItem(IDictionary<string, DynamoDBEntry> key, DeleteItemOperationConfig config)
        {
            return DeleteHelper(MakeKey(key), config, false);
        }

        #endregion

    }
}
