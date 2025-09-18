using System.Net.Http;
using UnityEngine;
using System.Threading.Tasks;

public class AulaPokemon : MonoBehaviour
{
    private HttpClient client = new HttpClient();
    private const string baseUrl = "https://pokeapi.co/api/v2/pokemon/";
  
    async void Start()
    {
        Pokemon ditto = await getPokemon("ditto");
        Debug.Log($"Nome: {ditto.name} - Peso: {ditto.weight}");
    }
    
    public async Task<Pokemon> getPokemon(string nomePokemon)
    {
        HttpResponseMessage response = await client.GetAsync(baseUrl + nomePokemon.ToLower());
        string responseJson = await response.Content.ReadAsStringAsync();
        Pokemon pokemon = JsonUtility.FromJson<Pokemon>(responseJson);  
        return pokemon;
    }
    
}
