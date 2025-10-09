﻿using Microsoft.OpenApi.Models;

namespace M8MusicAPI.Utils;

public class SwaggerConfig
{
    public string Title { get; set; }

    public string Description { get; set; }

    public OpenApiContact Contact { get; set; }

    public List<SwaggerServerConfig> Servers { get; set; }
}
