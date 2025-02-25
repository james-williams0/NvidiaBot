﻿using NvidiaBot.Responses;
using Refit;

namespace NvidiaBot.Clients;

public interface IFeInventoryClient
{
    [Get("/partner/v1/feinventory")]
    Task<FeInventoryResponse> GetFeInventoryAsync(string skus = "NVGFT590", string locale = "en-gb", int status = 1);
}
