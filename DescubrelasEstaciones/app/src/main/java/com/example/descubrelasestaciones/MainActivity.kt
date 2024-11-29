package com.example.descubrelasestaciones

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.descubrelasestaciones.adapters.AvataresAdapter
import com.example.descubrelasestaciones.classes.Avatar
import com.example.descubrelasestaciones.classes.InfoNen
import com.example.descubrelasestaciones.misc.BackgroundSound
import com.example.descubrelasestaciones.niveles.PantallaFinal
import com.example.descubrelasestaciones.niveles.Tutorial
import com.example.descubrelasestaciones.niveles.Tutorial.TutoriaConstats


class MainActivity : AppCompatActivity() {

    private val arrayOfAvataresTotales = mutableListOf(
        Avatar("Caballo",R.drawable.caballo), Avatar("Oveja",R.drawable.oveja),Avatar("Oso",R.drawable.oso),
        Avatar("Gallina",R.drawable.gallina), Avatar("Conejo",R.drawable.conejo), Avatar("Vaca",R.drawable.vaca),
        Avatar("Pollo",R.drawable.pollo), Avatar("Cerdo",R.drawable.cerdo), Avatar("Jirafa",R.drawable.jirafa),
        Avatar("Pato",R.drawable.pato), Avatar("León",R.drawable.leon), Avatar("Tigre",R.drawable.tigre),
        Avatar("Oso Panda",R.drawable.oso_panda), Avatar("Perro",R.drawable.perro), Avatar("Gato",R.drawable.gato),
        Avatar("Reno",R.drawable.reno), Avatar("Cangrejo",R.drawable.cangrejo), Avatar("Nutria",R.drawable.nutria),
        Avatar("Pinguino",R.drawable.pinguino), Avatar("Loro",R.drawable.loro), Avatar("Burro",R.drawable.burro),
        Avatar("Chocobo",R.drawable.chocobo), Avatar("Zorro",R.drawable.zorro), Avatar("Hurón",R.drawable.huron)
        )

    private var arrayOfAvatares = mutableListOf<Avatar>()
    private var arrayOfAvataresPantalla = mutableListOf<Avatar>()

    private lateinit var adapter: AvataresAdapter

    private var infoNen = InfoNen("Error",0,0,0,0,
        0.00,"Error","Error","Error","Error","Error","Exemple")

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        guardarYMostrarArray()

        startMusic()
        val recyclerViewAvatares = findViewById<RecyclerView>(R.id.ArrayAvatares)
        adapter = AvataresAdapter(this, arrayOfAvataresPantalla){ avatar ->
            arrayOfAvatares.remove(avatar)
            arrayOfAvataresPantalla.remove(avatar)
            val intent = Intent(this, Tutorial::class.java)
            infoNen.avatar = avatar.nombre
            Log.d("Nombre Avatar", infoNen.avatar)
            intent.putExtra(Tutorial.TutoriaConstats.INFONEN, infoNen)
            startActivity(intent)
            guardarYMostrarArray()
            adapter.notifyDataSetChanged()

        }
        recyclerViewAvatares.adapter = adapter
        recyclerViewAvatares.layoutManager = GridLayoutManager(this,4)
    }

    private fun guardarYMostrarArray() {
        if(arrayOfAvatares.size == 0){
            arrayOfAvatares.addAll(arrayOfAvataresTotales)
            arrayOfAvataresPantalla.addAll(mutableListOf(arrayOfAvatares[1],arrayOfAvatares[2],arrayOfAvatares[3],
                arrayOfAvatares[4],arrayOfAvatares[5],arrayOfAvatares[6],arrayOfAvatares[7],arrayOfAvatares[8]))
        }else{
            if (arrayOfAvatares.size !=0){
                for (i in 0 until arrayOfAvatares.size) {
                    if(!arrayOfAvataresPantalla.contains(arrayOfAvatares[i])){
                        arrayOfAvataresPantalla.add(arrayOfAvatares[i])
                    }
                    if(arrayOfAvataresPantalla.size == 8){
                        break
                    }
                }
            }
        }
    }

    private fun startMusic() {
        val intent = Intent(this, BackgroundSound::class.java)
        startService(intent)
    }
}