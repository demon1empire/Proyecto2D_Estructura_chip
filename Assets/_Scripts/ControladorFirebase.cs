using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine;
using System.Collections.Generic;

public class ControladorFirebase : MonoBehaviour
{
    FirebaseFirestore db;

    void Start()
    {
        // Esto verifica que el archivo google-services.json y las librerías estén sincronizados
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available) {
                // Si todo está bien, inicializamos la base de datos
                db = FirebaseFirestore.DefaultInstance;
                Debug.Log("¡Firebase conectado y listo para la UDG!");
            } else {
                Debug.LogError($"No se pudo conectar: {dependencyStatus}");
            }
        });
    }

    public void GuardarDatosPrueba()
    {
        if (db == null) {
            Debug.LogError("La base de datos no está lista. Revisa la consola.");
            return;
        }

        DocumentReference docRef = db.Collection("progreso_jugadores").Document("ruben_lomeli");
        
        Dictionary<string, object> progreso = new Dictionary<string, object>
        {
            { "monedas", 150 },
            { "nivel1_completado", true },
            { "nivel2_completado", false },
            { "fecha_actualizacion", System.DateTime.Now.ToString() }
        };

        docRef.SetAsync(progreso).ContinueWithOnMainThread(task => {
            if (task.IsCompleted) {
                Debug.Log("¡ÉXITO TOTAL! Los datos ya están en la nube.");
            } else {
                Debug.LogError("Error al guardar: " + task.Exception);
            }
        });
    }
}