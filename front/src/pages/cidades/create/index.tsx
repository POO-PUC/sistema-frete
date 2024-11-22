import { useState, useEffect } from 'react';
import { useRouter } from 'next/router';
import { useContext } from 'react';
import { CidadeContext } from '../../../contexts/CidadeContext';
import { EstadoContext } from '../../../contexts/EstadoContext'; // Importa o contexto de estados
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import { Select } from '../../../components/ui/Select'; // Importa o Select estilizado
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';
import { toast } from 'react-toastify';

const CreateCidade = () => {
  const { addCidade } = useContext(CidadeContext)!;
  const { estados, fetchEstados } = useContext(EstadoContext)!; // Obtém os estados
  const router = useRouter();

  const [codigo, setCodigo] = useState<number | ''>(''); // Campo para o código
  const [nome, setNome] = useState('');
  const [codigoDoEstado, setCodigoDoEstado] = useState<number | ''>(''); // Usaremos o código do estado selecionado
  const [precoPadrao, setPrecoPadrao] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    fetchEstados(); // Certifica que os estados estão carregados
  }, [fetchEstados]);

  const handleCreateCidade = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      if (codigo === '' || codigoDoEstado === '') {
        throw new Error('O código da cidade e o estado são obrigatórios.');
      }

      await addCidade({
        codigo, // Inclui o código no payload
        nome,
        codigoDoEstado, // Inclui o estado selecionado
        precoPadrao: parseFloat(precoPadrao),
      });
      toast.success('Cidade criada com sucesso!')
      router.push('/cidades');
    } catch (error) {
      console.error('Erro ao criar cidade:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.createCidadeContainer}>
          <h1>Criar Nova Cidade</h1>
          <form onSubmit={handleCreateCidade} className={styles.form}>
            <div className={styles.formGroup}>
              <label htmlFor="codigo">Código</label>
              <input
                id="codigo"
                type="number"
                value={codigo}
                onChange={(e) => setCodigo(Number(e.target.value))}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="nome">Nome da Cidade</label>
              <input
                id="nome"
                type="text"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="codigoDoEstado">Estado</label>
              <Select
                id="codigoDoEstado"
                value={codigoDoEstado}
                onChange={(e) => setCodigoDoEstado(Number(e.target.value))}
                required
              >
                <option value="">Selecione um Estado</option>
                {estados.map((estado) => (
                  <option key={estado.codigo} value={estado.codigo}>
                    {estado.nome}
                  </option>
                ))}
              </Select>
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="precoPadrao">Preço Padrão</label>
              <input
                id="precoPadrao"
                type="number"
                step="0.01"
                value={precoPadrao}
                onChange={(e) => setPrecoPadrao(e.target.value)}
                required
              />
            </div>

            <Button type="submit" loading={loading}>
              Criar Cidade
            </Button>
          </form>
        </div>
      </>
    </MainLayout>
  );
};

export default CreateCidade;
