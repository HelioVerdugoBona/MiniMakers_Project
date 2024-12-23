package com.example.descubrelasestaciones.niveles

import android.animation.ObjectAnimator
import android.animation.PropertyValuesHolder
import android.annotation.SuppressLint
import android.content.Intent
import android.media.MediaPlayer
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.util.Log
import android.view.DragEvent
import android.view.View
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.airbnb.lottie.LottieAnimationView
import com.example.descubrelasestaciones.classes.ItemEstaciones
import com.example.descubrelasestaciones.adapters.ItemsEstacionesAdapter
import com.example.descubrelasestaciones.R
import com.example.descubrelasestaciones.classes.Avatar
import com.example.descubrelasestaciones.niveles.ColoresEstaciones.ColoresConstats
import com.example.descubrelasestaciones.classes.InfoNen
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class RopasEstaciones: AppCompatActivity ()
{
    object RopasConstats {
        const val INFONEN = "INFONEN"
    }

    // Tiempo total en pasar el nivel
    private var startTime = System.currentTimeMillis()

    // Intentos (errores) totales en este nivel
    private var intentos = 0

    // Todos los Media Players
    private var infoNen = InfoNen("Exemple",0,0,0,0,
        0.00,0,0,0,0,"Exemple","Exemple")

    // Todos los Media Players
    private lateinit var correctSFX: MediaPlayer
    private lateinit var confetti: MediaPlayer
    private lateinit var yay: MediaPlayer
    private lateinit var aconseguit: MediaPlayer

    //Array donde guardar todas las animaciones
    private val arrayAnimationsCorrect = mutableListOf<LottieAnimationView>()

    //Array del RecyclerView de los Items (los objetos que se relacionarán)
    private val itemsEstaciones = mutableListOf<ItemEstaciones>()

    //Array del RecyclerView de las Estaciones
    private val arrayEstaciones = mutableListOf<ItemEstaciones>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.ropas_estaciones)
        setAllGlobal()

        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewRopas)
        val arrayEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewRopas2)
        setupRecyclerView(itemEstacionesList, itemsEstaciones,arrayEstacionesList,arrayEstaciones)
    }

    @SuppressLint("NotifyDataSetChanged")
    private fun setupRecyclerView(
        recyclerView1: RecyclerView,
        itemsEstaciones: MutableList<ItemEstaciones>,
        recyclerView2: RecyclerView,
        arrayEstaciones: MutableList<ItemEstaciones>
    ) {
        itemsEstaciones.shuffle()

        val adapterItem = ItemsEstacionesAdapter(this, itemsEstaciones, true)
        recyclerView1.layoutManager = GridLayoutManager(this,4)
        recyclerView1.adapter = adapterItem


        val adapterEstacion = ItemsEstacionesAdapter(this, arrayEstaciones, false)
        recyclerView2.layoutManager = GridLayoutManager(this,4)
        recyclerView2.adapter = adapterEstacion
        recyclerView1.setOnDragListener { _, event ->
            when (event.action) {
                DragEvent.ACTION_DRAG_STARTED  -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 0f

                    val targetPosition =
                        if (draggedView != null) {
                            recyclerView1.getChildAdapterPosition(draggedView)
                        } else {
                            RecyclerView.NO_POSITION
                        }
                    val item = itemsEstaciones[targetPosition]
                    item.sound.start()
                    true
                }else -> true

            }
        }
        recyclerView2.setOnDragListener { _, event ->
            when (event.action) {
                DragEvent.ACTION_DROP -> {
                    // val draggedItem = event.localState as ItemEstaciones
                    // Obtener el atributo del ítem arrastrado
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 1.0f
                    val draggedAttribute = event.clipData.getItemAt(0).text.toString()
                    println("El ID del draggedAttribute es: $draggedAttribute")

                    // Encuentra el ítem de destino (donde se soltó el arrastre)
                    val x = event.x
                    val y = event.y
                    val viewUnder = recyclerView2.findChildViewUnder(x, y)
                    val targetPosition = if (viewUnder != null) {
                        recyclerView2.getChildAdapterPosition(viewUnder)
                    } else {
                        RecyclerView.NO_POSITION
                    }
                    println("El targetPosition es: $targetPosition")


                    if (targetPosition != RecyclerView.NO_POSITION) {
                        val targetItem = arrayEstaciones[targetPosition]
                        targetItem.sound.start()
                        // Compara los atributos
                        if (draggedAttribute == targetItem.id) {
                            val iterator = itemsEstaciones.iterator()
                            while (iterator.hasNext()) {
                                val item = iterator.next()
                                if (draggedAttribute == item.id) {
                                    iterator.remove() // Elimina usando el iterador
                                    adapterItem.notifyDataSetChanged()
                                    runAnimatic(targetItem.id.toInt()-1,arrayAnimationsCorrect)
                                    correctSFX.start()
                                    Handler(Looper.getMainLooper()).postDelayed({
                                        if (viewUnder != null) {
                                            viewUnder.visibility = View.INVISIBLE
                                        }
                                    }, 500)
                                    adapterEstacion.notifyDataSetChanged()
                                    break // Salir del bucle después de eliminar
                                }
                            }
                            if(itemsEstaciones.size == 0){
                                val txtFelicitarView: TextView = findViewById(R.id.txtFelicitar)
                                val anmConfetti = findViewById<LottieAnimationView>(R.id.ANMConfetti)
                                val  txtFelicitar = "Ho has aconseguit!"
                                lifecycleScope.launch {
                                    txtFelicitarView.visibility = View.VISIBLE
                                    animateTxt(txtFelicitarView, txtFelicitar)
                                    aconseguit.start()
                                    anmConfetti.playAnimation()
                                    confetti.start()
                                    delay(2500)
                                    nextLevel()
                                }
                            }
                            Log.d("DragAndDrop", "Atributos coinciden")

                        } else {
                            Log.d("DragAndDrop", "Atributos no coinciden")
                            intentos++
                        }
                    }
                    true
                }
                DragEvent.ACTION_DRAG_ENDED -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 1.0f
                    true
                }

                else -> true
            }
        }
    }

    private fun nextLevel() {
        val intent = Intent(this, PantallaFinal::class.java)
        val endTime = System.currentTimeMillis()
        val elapsedTime = endTime - startTime // en milisegundos
        Log.d("Timer", "Tiempo transcurrido: ${elapsedTime}ms")
        infoNen.tempsNVL3 = (elapsedTime/1000).toInt()
        infoNen.erradesNVL3 = intentos
        intent.putExtra(PantallaFinal.InfoNens.INFONEN,infoNen)
        lifecycleScope.launch {
            delay(500)
            startActivity(intent)
            finish()
        }
    }

    private fun runAnimatic(index: Int, arrayAnimations: MutableList<LottieAnimationView>){
        arrayAnimations[index].visibility = View.VISIBLE
        arrayAnimations[index].playAnimation()
        lifecycleScope.launch {
            delay(1500)
            arrayAnimations[index].visibility = View.GONE
        }
    }

    @SuppressLint("SetTextI18n")
    private fun animateTxt(textView: TextView, text: String){
        CoroutineScope(Dispatchers.Main).launch {
            textView.text = ""
            for (i in text.indices) {
                textView.text = textView.text.toString() + text[i]
                animacionLetras(textView)
            }
        }
    }

    private fun animacionLetras(textView: TextView) {
        val scaleX = PropertyValuesHolder.ofFloat("scaleX", 1f, 1.5f, 1f)
        val scaleY = PropertyValuesHolder.ofFloat("scaleY", 1f, 1.5f, 1f)
        val translationY = PropertyValuesHolder.ofFloat("translationY", 0f, -50f, 0f)

        ObjectAnimator.ofPropertyValuesHolder(textView, scaleX, scaleY, translationY).apply {
            duration = 1000 // Duración del salto en milisegundos
            start()
        }
    }

    private fun setAllGlobal() {
        window.decorView.systemUiVisibility = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        val anmCorrect1 = findViewById<LottieAnimationView>(R.id.ANMCorrect1)
        val anmCorrect2 = findViewById<LottieAnimationView>(R.id.ANMCorrect2)
        val anmCorrect3 = findViewById<LottieAnimationView>(R.id.ANMCorrect3)
        val anmCorrect4 = findViewById<LottieAnimationView>(R.id.ANMCorrect4)
        arrayAnimationsCorrect.addAll(mutableListOf(anmCorrect1,anmCorrect2,anmCorrect3,anmCorrect4))

        correctSFX = MediaPlayer.create(this, R.raw.correctsfx)
        confetti = MediaPlayer.create(this, R.raw.confetti)
        yay = MediaPlayer.create(this, R.raw.yay)
        aconseguit = MediaPlayer.create(this, R.raw.hohasaconseguit)

        itemsEstaciones.addAll(mutableListOf(
            ItemEstaciones("1", "Banyador", R.drawable.banyador,MediaPlayer.create(this, R.raw.banyador)),
            ItemEstaciones("2", "Samarreta", R.drawable.camisetaflor,MediaPlayer.create(this, R.raw.samarreta)),
            ItemEstaciones("3", "Impermeable", R.drawable.chubasquero,MediaPlayer.create(this, R.raw.impermeable)),
            ItemEstaciones("4", "Bufanda", R.drawable.bufanda,MediaPlayer.create(this, R.raw.bufanda))
        ))

        arrayEstaciones.addAll(mutableListOf(
            ItemEstaciones("1", "Verano", R.drawable.estiu,MediaPlayer.create(this, R.raw.estiu)),
            ItemEstaciones("2", "Primavera", R.drawable.primavera,MediaPlayer.create(this, R.raw.primavera)),
            ItemEstaciones("3", "Otoño", R.drawable.tardor,MediaPlayer.create(this, R.raw.tardor)),
            ItemEstaciones("4", "Invierno", R.drawable.hivern,MediaPlayer.create(this, R.raw.hivern))
        ))

        val intent = intent
        infoNen = intent.getSerializableExtra(ColoresConstats.INFONEN) as InfoNen
    }

}