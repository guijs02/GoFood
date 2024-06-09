using GoFood.Domain.Google.Places.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using SistemaWeb.API.Controllers;

namespace GoFood.Test
{
    public class GoFoodTestAPI
    {
        private readonly Mock<HttpClient> httpClientMock;
        private readonly IConfigurationRoot configurationMock;
        private readonly PlacesController PlacesController;
        public GoFoodTestAPI()
        {
            httpClientMock = new Mock<HttpClient>();

            configurationMock = new ConfigurationBuilder()
                .AddUserSecrets<GoFoodTestAPI>()
                .Build();

            PlacesController =
             new PlacesController(httpClientMock.Object, configurationMock);
        }
        [Fact]
        public async Task TestarSeRetornaOsRestaurantes()
        {
            //ARRANGE
            PlacesRequest placesRequest = new PlacesRequest()
            {
                lat = -22.4107652,
                lng = -47.5596215,
                radius = "100",
                filtroPlaces = new FiltroPlaces()
            };

            //ACT
            OkObjectResult? places = await PlacesController.GetNearbyPlaces(placesRequest) as OkObjectResult;
            var root = SerializeJsonTest.ReadJsonAsObject<Root>(places.Value as string);

            //ASSERT
            Assert.NotNull(places);
            Assert.NotNull(root);
        }

        [Fact]
        public async Task TestarExcecaoQuandoConteudoDaRequisicaoEhNulo()
        {
            //ARRANGE
            PlacesRequest? placesRequest = null;

            //ACT
            var placesDelegate = async () => await PlacesController.GetNearbyPlaces(placesRequest);

            //ASSERT 
            await Assert.ThrowsAsync<NullReferenceException>(placesDelegate);

        }
        [Fact]
        public async Task TestarRetornoInvalidoDaAPI()
        {
            //ARRANGE
            PlacesRequest? placesRequest = new PlacesRequest();

            string responseInvalidRequest = "INVALID_REQUEST";

            //ACT
            var request = await PlacesController.GetNearbyPlaces(placesRequest) as OkObjectResult;

            bool? IsInvalid = request?.Value.ToString().Contains(responseInvalidRequest);

            //ASSERT
            Assert.True(IsInvalid);
            Assert.NotNull(request.Value);
        }
        [Fact]
        public async Task TestarRetornoPositivoLocationController()
        {
            //ARRANGE
            string endereco = "Rio Claro, SP";

            var locationController = new LocationController(httpClientMock.Object, configurationMock);

            //ACT
            var response = await locationController.GetLocationAsync(endereco);

            //ASSERT
            Assert.IsType<OkObjectResult>(response);

            var result = response as OkObjectResult;

            Assert.NotNull(result.Value);
        }
    }
}
