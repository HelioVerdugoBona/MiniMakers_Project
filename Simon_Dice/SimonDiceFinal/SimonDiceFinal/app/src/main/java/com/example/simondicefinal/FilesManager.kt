package com.example.simondicefinal

import android.content.Context
import com.example.simondicefinal.datamodel.Partida
import com.google.firebase.crashlytics.buildtools.reloc.com.google.common.reflect.TypeToken
import com.google.gson.Gson
import java.io.FileReader
import java.io.FileWriter
import java.io.File

class FilesManager {
    companion object {
        // Comprueba si el archivo de las partidas existe y si tiene contenido dentro
        fun comprovarArchivo(context: Context): Boolean {
            val jsonFilePath = context.getFilesDir().toString() + "/partidasSimon.json"
            val jsonFile = File(jsonFilePath)
            return jsonFile.exists() && jsonFile.length() != 0L
        }

        // Lee el archivo de las partidas guardadas y lo convierte un una MutableList
        fun obtenerPartidas(context: Context): MutableList<Partida> {
            val jsonFilePath = context.getFilesDir().toString() + "/partidasSimon.json"
            val jsonFile = FileReader(jsonFilePath)
            val listPartidasType = object: TypeToken<MutableList<Partida>>() {}.type
            val partidas: MutableList<Partida> = Gson().fromJson(jsonFile, listPartidasType)
            return partidas
        }

        // Recive una MutableList y guarda los datos en el archivo de partidas guardadas
        fun guardarPartidas(context: Context, partidas: List<Partida>) {
            val jsonFilePath = context.getFilesDir().toString() + "/partidasSimon.json"
            val jsonFile = FileWriter(jsonFilePath)
            var gson = Gson()
            var jsonElement = gson.toJson(partidas)
            jsonFile.write(jsonElement)
            jsonFile.close()
        }
    }
}
