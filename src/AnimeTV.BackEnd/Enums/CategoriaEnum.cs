using System.Text.Json.Serialization;

namespace AnimeTV.BackEnd.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoriaEnum
    {
        ACAO,
        AVENTURA,
        COMEDIA,
        DRAMA,
        FANTASIA,
        TERROR,
        ROMANCE,
        FICCAO_CIENTIFICA,
        MAGIA,
        MECHA,
        MUSICAL,
        SHOUJO,
        SHOUNEN,
        ESPORTE,
        PSICOLOGICO,
        SOBRENATURAL,
        HORROR,
        MISTERIO,
        SUPERPODER,
        JOGO,
        HISTORICO,
        DEMONIOS,
        ECCHI,
        ARTES_MARCIAIS,
        ESPACO,
        POLICIAL,
        VIDA_ESCOLAR,
        MILITAR,
        SAMURAI,
        VAMPIRO,
        YAOI,
        YURI,
        HAREM,
        SEINEN,
        SHOUJO_AI,
        SHOUNEN_AI,
        ESPORTE_RADICAL
    }
}
