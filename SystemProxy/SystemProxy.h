#pragma once

#include "pch.h"

// @brief: 设置windows系统代理
// @param method: 0 关闭代理 | 1 全局代理 | 2 PAC代理
// @param server: 服务器地址, 关闭代理的时候传空, 全局代理的时候地址不要加 http://, pac代理要加http://
// @ret：0 成功 | 非 0 即为error code
EXPORT_FUNC int SetSystemProxy(int method, const char* server);
