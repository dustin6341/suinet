﻿using Suinet.Rpc.Api;

namespace Suinet.Rpc.Client
{
    public interface IJsonRpcApiClient : IReadApi, IExtendedApi, IGenericReadApi, ICoinQueryApi, ITransactionBuilderApi
    {
    }
}
