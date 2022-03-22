#pragma once
#include "ICanvas.h"


class IDrawable
{
public:
	virtual void Draw(ICanvas& cnavas) const = 0;
	virtual ~IDrawable() = default;
};

