#pragma once

#include "pch.h"

// @brief: ����windowsϵͳ����
// @param method: 0 �رմ��� | 1 ȫ�ִ��� | 2 PAC����
// @param server: ��������ַ, �رմ����ʱ�򴫿�, ȫ�ִ����ʱ���ַ��Ҫ�� http://, pac����Ҫ��http://
// @ret��0 �ɹ� | �� 0 ��Ϊerror code
EXPORT_FUNC int SetSystemProxy(int method, const char* server);
