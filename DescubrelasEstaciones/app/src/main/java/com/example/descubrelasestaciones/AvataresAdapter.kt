package com.example.descubrelasestaciones

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.RecyclerView

class AvataresAdapter(
    private val context: Context,
    private val avatares: MutableList<Avatar>,
    private val onItemClickListener: (Avatar) -> Unit // Función de clic como parámetro
) : RecyclerView.Adapter<AvataresAdapter.AvataresViewHolder>() {

    private val layout = R.layout.avatar_item

    // ViewHolder para almacenar la vista de cada item
    inner class AvataresViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        private val imagenImageView: ImageView = itemView.findViewById(R.id.ImgAvatar)

        fun bindAvatar(avatar: Avatar) {
            imagenImageView.setImageResource(avatar.imagen)

            // Configurar el evento de clic para este elemento
            itemView.setOnClickListener {
                onItemClickListener(avatar) // Llama a la función de clic con el avatar seleccionado
            }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AvataresViewHolder {
        // Inflar el layout para el item del RecyclerView
        val view = LayoutInflater.from(context).inflate(layout, parent, false)
        return AvataresViewHolder(view)
    }

    override fun onBindViewHolder(holder: AvataresViewHolder, position: Int) {
        // Obtener el avatar en la posición actual y enlazarlo a la vista
        val avatar = avatares[position]
        holder.bindAvatar(avatar)
    }

    override fun getItemCount(): Int {
        // Retornar el tamaño de la lista de avatares
        return avatares.size
    }
}