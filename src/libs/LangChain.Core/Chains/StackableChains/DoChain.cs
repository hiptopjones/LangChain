﻿using LangChain.Abstractions.Schema;
using LangChain.Chains.HelperChains;

namespace LangChain.Chains.StackableChains;

/// <summary>
/// 
/// </summary>
public class DoChain : BaseStackableChain
{
    private readonly Action<Dictionary<string, object>> _func;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="func"></param>
    public DoChain(Action<Dictionary<string, object>> func)
    {
        _func = func;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    protected override Task<IChainValues> InternalCall(IChainValues values)
    {
        values = values ?? throw new ArgumentNullException(nameof(values));
        
        _func(values.Value);
        
        return Task.FromResult(values);
    }
}