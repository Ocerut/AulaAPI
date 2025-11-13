using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;

public class API : MonoBehaviour
{
    private GameApiService apiService;
    
    async void Start()
    {
        apiService = new GameApiService();
        
        Debug.Log("=== TESTE DA API ===");

        //Adicionar Jogadores
        //Player novoJogador1 = new Player();
        //novoJogador1.Vida = 100;
        //novoJogador1.QtdeItens = 0;
        //novoJogador1.PosX = 0;
        //novoJogador1.PosY = 0;
        //novoJogador1.PosZ = 0;
        ////adicionar jogador na API
        //Player criadoJogador1 = await apiService.CriarJogador(novoJogador1);
        //Player novoJogador2 = new Player();
        //novoJogador2.Vida = 95;
        //novoJogador2.QtdeItens = 0;
        //novoJogador2.PosX = 10;
        //novoJogador2.PosY = 0;
        //novoJogador2.PosZ = 0;
        ////adicionar jogador na API
        //Player criadoJogador2 = await apiService.CriarJogador(novoJogador2);
        //Debug.Log($"Jogadores criados: (ID: {criadoJogador1.id}), (ID: {criadoJogador2.id})");
        //adicionar itens para o jogador 1
        //ItemJogador novoItem1 = new ItemJogador();
        //novoItem1.Nome = "Espada";
        //novoItem1.Descricao = "Espada de Aço";
        //novoItem1.Dano = 10;
        //novoItem1.JogadorId = criadoJogador1.id;
        //ItemJogador criadoItem1 = await apiService.AdicionarItem(criadoJogador1.id, novoItem1);
        //ItemJogador novoItem2 = new ItemJogador();
        //novoItem2.Nome = "Escudo";
        //novoItem2.Descricao = "Escudo de Madeira";
        //novoItem2.Dano = 5;
        //novoItem2.JogadorId = criadoJogador1.id;
        //ItemJogador criadoItem2 = await apiService.AdicionarItem(criadoJogador1.id, novoItem2);
        ////alterar vida do jogador 1
        //criadoJogador1.Vida = 80;
        //Player atualizadoJogador1 = await apiService.AtualizarJogador(criadoJogador1.id, criadoJogador1);

        //excluir item do jogador 2
        //await apiService.RemoverItem(criadoJogador1.id, criadoItem2.id);

        //mostrar todos os jogadores
        await MostrarTodosJogadores();


        Debug.Log("=== FIM DOS TESTES ===");
    }
    
    async Task MostrarTodosJogadores()
    {
        Player[] jogadores = await apiService.GetTodosJogadores();
        Debug.Log($"Total de jogadores: {jogadores.Length}");
        foreach (var jogador in jogadores)
        {
            Debug.Log($"Jogador: (ID: {jogador.Id}, Vida: {jogador.Vida})");
            //ItemJogador[] itens = await apiService.GetItensJogador(jogador.id);
            //Debug.Log($"  Itens ({itens.Length}):");
            //foreach (var item in itens)
            //{
            //    Debug.Log($"    - {item.Nome} (Dano: {item.Dano})");
            //}
        }
    }


    void OnDestroy()
    {
        apiService?.Dispose();
    }
}