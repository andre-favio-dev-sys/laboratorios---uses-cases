using System;
using System.Collections.Generic;

namespace Lab_06_Andre_Ancco.Models;

/// <summary>
/// Stores OAuth states for third-party provider authentication flows where Supabase acts as the OAuth client.
/// </summary>
public partial class OauthClientState
{
    public Guid Id { get; set; }

    public string ProviderType { get; set; } = null!;

    public string? CodeVerifier { get; set; }

    public DateTime CreatedAt { get; set; }
}
