using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(GameData data);

    // É uma referência pois queremos que o script tenha a liberdade de modificar os valores.
    // Diferente do objeto de cima que apenas tem permissão para ser lido
    void SaveData(ref GameData data);
}
