﻿using Suinet.Rpc.Types;
using Suinet.Rpc.Types.ObjectDataParsers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suinet.Rpc.Api
{
    public interface IGenericReadApi
    {
        Task<RpcResult<T>> GetObjectAsync<T>(string objectId, IObjectDataParser<T> parser, ObjectDataOptions options = null) where T : class;

        Task<RpcResult<T>> GetDynamicFieldObjectAsync<T>(string parentObjectId, string fieldName) where T : class;

        Task<RpcResult<IEnumerable<T>>> GetObjectsOwnedByAddressAsync<T>(string ownerAddress, IObjectDataParser<T> parser, string cursor, ulong? limit, ObjectDataOptions options = null) where T : class;

        Task<RpcResult<IEnumerable<T>>> GetOwnedObjectsAsync<T>(string ownerAddress, IObjectDataParser<T> parser, ObjectResponseQuery query, string cursor, ulong? limitl) where T : class;

        Task<RpcResult<IEnumerable<T>>> GetObjectsAsync<T>(IEnumerable<string> objectIds, IObjectDataParser<T> parser, ObjectDataOptions options = null) where T : class;
    }
}
