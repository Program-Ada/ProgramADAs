using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "ProgramADA";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption){
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load(string profileId){

        // Usa Path.Combine para evitar erros de diferentes sistemas operacionais
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        GameData loadedData = null;

        if(File.Exists(fullPath)){
            try{

                // Carrega os dados serializados do arquivo
                string dataToLoad = "";

                using(FileStream stream = new FileStream(fullPath, FileMode.Open)){

                    using(StreamReader reader = new StreamReader(stream)){
                        dataToLoad = reader.ReadToEnd();
                    }

                }

                // Desencrypta os dados
                if(useEncryption){
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                // Desserializa os dados do arquivo JSON de volta para Objeto C#
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }catch(Exception e){
                Debug.LogError("erro ocorreu ao tentar carregar os dados do arquivo: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data, string profileId){
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);

        try{
            // Cria o diretório. O arquivo será criado caso ainda não exista
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serializa os dados do jogo em C# para um arquivo JSON
            string dataToStore = JsonUtility.ToJson(data, true);

            // Encrypta os dados
            if(useEncryption){
                dataToStore = EncryptDecrypt(dataToStore);
            }

            // Escreve os dados serializados no arquivo JSON
            using(FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using(StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(dataToStore);
                }
            }
        }catch(Exception e){
            Debug.LogError("Erro ocorreu ao tentar salvar os dados no arquivo: " + fullPath + "\n" + e);
        }
    }

    public Dictionary<string, GameData> loadAllProfiles(){
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        // Fazer um loop que passe pelos nomes dos diretórios dentro do caminho do diretório de dados
        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();
        foreach(DirectoryInfo dirInfo in dirInfos){
            string profileId = dirInfo.Name;

            // Programação defendiva -> verificar se o arquivo realmente existe
            // Caso não exista, então essa pasta não é um perfil e deveria ser pulado
            string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
            if(!File.Exists(fullPath)){
                Debug.LogWarning("Pulando esse diretório ao carregar todos por não conter dados: " + profileId);
                continue;
            }

            // Carrega os dados de jogo desse perfil e o coloca no dicionário
            GameData profileData = Load(profileId);

            // Programação defensiva -> Conferir se os dados do perfil não estão vazios
            if(profileData != null){
                profileDictionary.Add(profileId, profileData);
            }else{
                Debug.LogError("Tentativa de carregamento de perfil de errado. Id do Perfil: " + profileId);
            }
        }

        return profileDictionary;
    }

    private string EncryptDecrypt(string data){
        string modifiedData = "";
        for(int i = 0; i < data.Length; i++){
            modifiedData += (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}
