package com.example.descubrelasestaciones.misc

import android.content.Context

import android.os.Environment
import com.example.descubrelasestaciones.classes.InfoNen
import com.google.gson.Gson
import com.google.gson.reflect.TypeToken
import java.io.File
import java.io.FileReader
import java.io.FileWriter

class FileManager
{
    companion object
    {

        fun comproveFile(context: Context): Boolean
        {
            val jsonFilePath =File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS), "/EstacionesData.json")
//            val jsonFilePath = context.filesDir.toString() + "/EstacionesData.json"
//            val jsonFile = File(jsonFilePath)
            return jsonFilePath.exists() && jsonFilePath.length() != 0L
        }

        fun getUsersStats(context: Context): MutableList<InfoNen>
        {
            val jsonFilePath =File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS), "/EstacionesData.json")
//            val jsonFilePath = context.filesDir.toString() + "/EstacionesData.json"
            val jsonFile = FileReader(jsonFilePath)
            val listUsersType = object : TypeToken<MutableList<InfoNen>>() {}.type
            val arrayUsersData: MutableList<InfoNen> = Gson().fromJson(jsonFile,listUsersType)
            return arrayUsersData
        }

        fun saveUsersStats(context: Context, arrayUsersData: List<InfoNen>)
        {
            val jsonFilePath =File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS), "/EstacionesData.json")
//            val jsonFilePath = context.filesDir.toString() + "/EstacionesData.json"
            val jsonFile = FileWriter(jsonFilePath)
            val gson = Gson()
            val jsonElement = gson.toJson(arrayUsersData)
            jsonFile.write(jsonElement)
            jsonFile.close()
        }
    }
}
