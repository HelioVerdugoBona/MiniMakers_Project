package com.example.simondicefinal.activities

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.simondicefinal.R

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        // Asignar los elementos del layout a su varible correspondiente
        val btnIniciar = findViewById<Button>(R.id.BtnIniciar)
        val btnReglas = findViewById<Button>(R.id.BtnReglas)
        val txtNombre = findViewById<EditText>(R.id.TxtNombre)

        // Al pulsar el botón iniciar comprovar que se ha introducido un nombre y iniciar la activity del juego
        btnIniciar.setOnClickListener {
            if (txtNombre.text.toString() != "") {
                val intent = Intent(this, SimonActivity::class.java)
                intent.putExtra("NOMBRE", txtNombre.text.toString())
                startActivity(intent)
                txtNombre.text.clear()
            }else
            {
                Toast.makeText(this, "Introduce un nombre", Toast.LENGTH_LONG).show()
            }
        }

        // Al pulsar el botón reglas iniciarl la activity de las reglas
        btnReglas.setOnClickListener {
            val intent = Intent(this, RulesActivity::class.java)
            startActivity(intent)
        }

    }

}