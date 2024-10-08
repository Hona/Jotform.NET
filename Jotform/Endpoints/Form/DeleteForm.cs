﻿namespace Jotform;

public partial class JotformClient
{
    /// <summary>
    /// Delete an existing form.
    /// </summary>
    /// <param name="formId">Form ID.</param>
    public async Task<JotformResult<Models.Shared.Form>?> DeleteFormAsync(string formId, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.DeleteAsync($"form/{formId}", cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<JotformResult<Models.Shared.Form>>(_jsonSerializerOptions, cancellationToken)
            .ConfigureAwait(false);
    }
}