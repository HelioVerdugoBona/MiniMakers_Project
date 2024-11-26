package com.example.descubrelasestaciones

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
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.airbnb.lottie.LottieAnimationView
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch


class ColoresEstaciones: AppCompatActivity() {

    object ColoresConstats {
        const val INFONEN = "INFONEN"
    }

    private var startTime = System.currentTimeMillis()
    private var intentos = 0
    private var infoNen = InfoNen("Error",0,0,0,0,
        0.00,"Error","Error","Error","Error")

    private lateinit var correctSFX: MediaPlayer
    private lateinit var confetti: MediaPlayer
    private lateinit var yay: MediaPlayer
    private lateinit var aconseguit: MediaPlayer

    private lateinit var anmCorrect1: LottieAnimationView
    private lateinit var anmCorrect2: LottieAnimationView
    private lateinit var anmCorrect3: LottieAnimationView
    private lateinit var anmCorrect4: LottieAnimationView

    private val arrayAnimationsCorrect by lazy {
        mutableListOf (anmCorrect1,
                        anmCorrect2,
                        anmCorrect3,
                        anmCorrect4)
    }

    private lateinit var anmConfetti: LottieAnimationView

    private val itemsEstaciones = mutableListOf<ItemEstaciones>()
    private val arrayEstaciones = mutableListOf<ItemEstaciones>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.colores_estaciones)

        anmCorrect1 = findViewById(R.id.ANMCorrect1)
        anmCorrect2 = findViewById(R.id.ANMCorrect2)
        anmCorrect3 = findViewById(R.id.ANMCorrect3)
        anmCorrect4 = findViewById(R.id.ANMCorrect4)
        anmConfetti = findViewById(R.id.ANMConfetti)

        window.decorView.systemUiVisibility = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)
        correctSFX = MediaPlayer.create(this, R.raw.correctsfx)
        confetti = MediaPlayer.create(this, R.raw.confetti)
        yay = MediaPlayer.create(this, R.raw.yay)
        aconseguit = MediaPlayer.create(this, R.raw.hohasaconseguit)

        itemsEstaciones.addAll(mutableListOf( ItemEstaciones("1", "Amarillo", R.drawable.coloramarillo,MediaPlayer.create(this, R.raw.groc)),
            ItemEstaciones("2", "Rosa", R.drawable.colorrosa,MediaPlayer.create(this, R.raw.rosa)),
            ItemEstaciones("3", "Naranja", R.drawable.colornaranja,MediaPlayer.create(this, R.raw.taronja)),
            ItemEstaciones("4", "Azul_Cielo", R.drawable.colorazul,MediaPlayer.create(this, R.raw.blau))))

        arrayEstaciones.addAll(mutableListOf(ItemEstaciones("1", "Verano", R.drawable.estiu,MediaPlayer.create(this, R.raw.estiu)),
            ItemEstaciones("2", "Primavera", R.drawable.primavera,MediaPlayer.create(this, R.raw.primavera)),
            ItemEstaciones("3", "Otoño", R.drawable.tardor,MediaPlayer.create(this, R.raw.tardor)),
            ItemEstaciones("4", "Invierno", R.drawable.hivern,MediaPlayer.create(this, R.raw.hivern))))

        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewColores)
        val arrayEstacionesList = findViewById<RecyclerView>(R.id.recylerViewEstaciones)

        val intent = intent
        infoNen = intent.getSerializableExtra(ColoresConstats.INFONEN) as InfoNen
        setupRecyclerView(itemEstacionesList, itemsEstaciones,arrayEstacionesList,arrayEstaciones)

    }

    @SuppressLint("ResourceAsColor")
    private fun setupRecyclerView(
        recyclerView1: RecyclerView,
        itemsEstaciones: MutableList<ItemEstaciones>,
        recyclerView2: RecyclerView,
        arrayEstaciones: MutableList<ItemEstaciones>
    ) {

        itemsEstaciones.shuffle()

        val adapterItem = ItemsEstacionesAdapter(this, itemsEstaciones, true)
        recyclerView1.layoutManager = LinearLayoutManager(this)
        recyclerView1.layoutManager = GridLayoutManager(this,4)

        recyclerView1.adapter = adapterItem

        val adapterEstacion = ItemsEstacionesAdapter(this, arrayEstaciones, false)
        recyclerView2.layoutManager = LinearLayoutManager(this)
        recyclerView2.layoutManager = GridLayoutManager(this,4)

        recyclerView2.adapter = adapterEstacion

        recyclerView1.setOnDragListener { view, event ->
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

        recyclerView2.setOnDragListener { view, event ->
            when (event.action) {
                DragEvent.ACTION_DROP -> {
                    val draggedView = event.localState as? View
                    draggedView?.alpha = 1.0f

                    val draggedAttribute = event.clipData.getItemAt(0).text.toString()
                    view.alpha = 1.0f
                    // Encuentra el ítem de destino (donde se soltó el arrastre)
                    val x = event.x
                    val y = event.y
                    val viewUnder = recyclerView2.findChildViewUnder(x, y)
                    val targetPosition =
                        if (viewUnder != null) {
                        recyclerView2.getChildAdapterPosition(viewUnder)
                    } else {
                        RecyclerView.NO_POSITION
                    }

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
                                    // viewUnder?.setBackgroundColor(ContextCompat.getColor(this, R.color.green))
                                    runAnimatic(targetItem.id.toInt()-1,arrayAnimationsCorrect)
                                    correctSFX.start()
                                    Handler(Looper.getMainLooper()).postDelayed({
                                        if (viewUnder != null) {
                                            viewUnder.visibility = View.INVISIBLE
                                        }
                                    }, 500)

                                    break // Salir del bucle después de eliminar
                                }
                            }
                            if(itemsEstaciones.size == 0){
                                val txtFelicitarView: TextView = findViewById(R.id.txtFelicitar)
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

        val endTime = System.currentTimeMillis()
        val elapsedTime = endTime - startTime // en milisegundos
        Log.d("Timer", "Tiempo transcurrido: ${elapsedTime}ms")
        infoNen.tempsNVL1 = ((elapsedTime/1000).toInt())
        val intent = Intent(this, SimbolosEstaciones::class.java)
        infoNen.erradesNVL1 = intentos.toString()
        intent.putExtra(SimbolosEstaciones.SimbolosConstats.INFONEN,infoNen)

        lifecycleScope.launch {
            delay(500)
            startActivity(intent)
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

    private fun animateTxt(textView: TextView, text: String){
        CoroutineScope(Dispatchers.Main).launch {
            textView.text = ""
            for (i in text.indices) {
                textView.text = textView.text.toString() + text[i]
                animacionLetras(textView, i)
            }
        }
    }

    private fun animacionLetras(textView: TextView, index: Int) {
        val scaleX = PropertyValuesHolder.ofFloat("scaleX", 1f, 1.5f, 1f)
        val scaleY = PropertyValuesHolder.ofFloat("scaleY", 1f, 1.5f, 1f)
        val translationY = PropertyValuesHolder.ofFloat("translationY", 0f, -50f, 0f)

        ObjectAnimator.ofPropertyValuesHolder(textView, scaleX, scaleY, translationY).apply {
            duration = 1000 // Duración del salto en milisegundos
            start()
        }
    }
}