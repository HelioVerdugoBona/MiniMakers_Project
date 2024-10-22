package com.example.descubrelasestaciones

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity

class ColoresEstaciones: AppCompatActivity()
{
    object estacionesConstats
    {
        const val AVATAR = "AVATAR"
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.colores_estaciones)

    }

}